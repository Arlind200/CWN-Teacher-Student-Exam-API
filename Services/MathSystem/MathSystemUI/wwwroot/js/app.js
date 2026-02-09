const API_BASE = "http://localhost:5265/api/v1/Exam";

async function loadStudentResults() {
    const examInput = document.getElementById("studentId");
    const tbody = document.querySelector("#studentTable tbody");
    const scoreContainer = document.getElementById("scoreContainer");

    if (!examInput) return;

    const examId = examInput.value;
    if (!examId) return;

    const response = await fetch(`${API_BASE}/student/${examId}`);
    const data = await response.json();

    tbody.innerHTML = "";
    scoreContainer.classList.add("hidden");

    if (!data || data.length === 0) return;

    const exam = data[0];

    exam.tasks.forEach(t => {
        tbody.innerHTML += `
      <tr>
        <td>${t.taskId}</td>
        <td>${t.expression}</td>
        <td>${t.expected}</td>
        <td>${t.actual}</td>
        <td>${t.isCorrect ? "Correct" : "Incorrect"}</td>
      </tr>
    `;
    });

    renderScore(exam.scorePercentage);
}

function renderScore(percentage) {
    const circle = document.querySelector(".progress-ring__circle");
    const radius = circle.r.baseVal.value;
    const circumference = 2 * Math.PI * radius;

    circle.style.strokeDasharray = `${circumference} ${circumference}`;

    const offset = circumference - (percentage / 100) * circumference;
    circle.style.strokeDashoffset = offset;

    document.getElementById("scorePercent").textContent = `${percentage}%`;
    document.getElementById("scoreContainer").classList.remove("hidden");
}



async function uploadXml() {
    const file = document.getElementById("xmlFile").files[0];
    if (!file) return alert("Select XML file");

    const formData = new FormData();
    formData.append("file", file);

    const response = await fetch(`${API_BASE}/upload`, {
        method: "POST",
        body: formData // ❗ NO headers
    });

    if (!response.ok) {
        console.error("Upload failed:", response.status);
        return;
    }

    alert("XML uploaded successfully");
}


async function loadExamResults() {
    const examId = document.getElementById("examId").value;
    const response = await fetch(`${API_BASE}/results/${examId}`);
    const data = await response.json();

    const tbody = document.querySelector("#teacherTable tbody");
    tbody.innerHTML = "";

    data.forEach(r => {
        const row = `<tr>
      <td>${r.studentId}</td>
      <td>${r.correctTasks}</td>
      <td>${r.totalTasks}</td>
      <td>${r.scorePercentage}%</td>
    </tr>`;
        tbody.innerHTML += row;
    });
}
