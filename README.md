### CWN-Teacher-Student-Exam-API

### Summary
CWN-Teacher-Student-Exam-API is a project to showcase the usage of CQRS pattern, data is fetched via `SQLite`, frontend is a simple `HTML`,`CSS`,`JS` stack.
The program has its limitations on usage, a suitable userstory would be, teacher uploads the XML -> teacher views the exam -> student views the exam
This is the first version of the app.

---

### API layer
- CQRS pattern
- SQLite database with EF core as database
- Three endpoints (UploadExam POST, GetExamsByExamId GET, GetExamByStudentId GET)
- No logic for duplicate xml loading
- CLEAN architecture, clear seperation of concerns between layers, dependencies pointing inward

---

### Frontend
- Rendered student exam results directly into table
- Added circular progress UI based on `scorePercentage`
- UI only renders when valid data is returned
- Improved defensive checks to prevent runtime errors

---

### What Works
- Student results load correctly
- Score percentage accurately reflected in UI
- No UI blocking or crashes
- Clean separation between teacher and student views

---

### Known Limitations
- No loading indicator while fetching data
- No user-facing error UI on network/API failure
- Student endpoint returns array instead of single object
- System knows to parse only the following XML 
```<Teacher Id = "11111">
<Students>
  <Student Id="12345">
      <Exam Id="1">
          <Task Id = "1"> 2+3*7-4 = -2 </Task >
          <Task Id = "2"> 6*2+3-4 = 11 </Task >
      </Exam>
  </Student>
  <Student Id="54321">
      <Exam Id="1">
          <Task Id = "1"> 2+3/6-4 = 74 </Task >
          <Task Id = "2"> 6*2+3-4 = 22 </Task >
      </Exam>
  </Student>
  <Student Id="12321">
      <Exam Id="1">
          <Task Id = "1"> 2+3/6-4 = 74 </Task >
          <Task Id = "2"> 6*2+3-4 = 22 </Task >
      </Exam>
  </Student>
  <!-- More Students-->
</Students >
</Teacher>
```


---

### Manual Testing
- Verified with valid exam ID
- Verified with exam containing zero correct tasks
- Verified with empty response
- Tests were not written integration nor unit tests
