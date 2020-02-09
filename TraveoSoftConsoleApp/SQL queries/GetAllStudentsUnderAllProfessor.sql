select distinct s.studentName as StudentName, p.professorName as ProfessorName from professor p 
left join student s 
on p.coursename= s.coursename 
group by p.professorName,s.studentName