using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.Models;

namespace myAppMemory.ViewModels {
  public class Repo_Student : RepositoryBase {
    public IEnumerable<StudentName> getStudentNames() {
      var st = dc.Students.OrderBy(n => n.LastName);

      List<StudentName> rls = new List<StudentName>();

      foreach (var item in st) {
        StudentName stu = new StudentName();
        stu.StudentId = item.Id;
        stu.FirstName = item.FirstName;
        stu.LastName = item.LastName;
        rls.Add(stu);
      }

      return rls;

    }

    public IEnumerable<StudentFull> getStudentsFull() {
      var st = dc.Students.Include("Courses").OrderBy(n => n.LastName);

      List<StudentFull> rls = new List<StudentFull>();

      foreach (var item in st) {
        StudentFull stu = new StudentFull();
        stu.StudentId = item.Id;
        stu.FirstName = item.FirstName;
        stu.LastName = item.LastName;
        stu.Phone = item.Phone;
        stu.StudentNumber = item.StudentNumber;
        stu.Courses = Repo_Courses.getCourseForList(item.Courses);
        rls.Add(stu);
      }

      return rls;

    }

    public IEnumerable<StudentPublic> getStudentsPublic() {
      var st = dc.Students.OrderBy(n => n.StudentNumber);

      List<StudentPublic> rls = new List<StudentPublic>();

      foreach (var item in st) {
        StudentPublic stu = new StudentPublic();
        stu.FirstName = item.FirstName;
        stu.LastName = item.LastName;
        stu.Phone = item.Phone;
        stu.StudentNumber = item.StudentNumber;
        rls.Add(stu);
      }

      return rls;

    }

    public IEnumerable<StudentsForList> getForList() {
      var ls = dc.Students.OrderBy(n => n.Id);

      List<StudentsForList> rls = new List<StudentsForList>();

      foreach (var item in ls) {
        StudentsForList stu = new StudentsForList();
        stu.StudentId = item.Id;
        stu.StudentNumber = item.StudentNumber;
        rls.Add(stu);
      }

      return rls;
    }

    public StudentPublic getStudentPublic(int? id) {
      var st = dc.Students.FirstOrDefault(n => n.Id == id);

      StudentPublic stu = new StudentPublic();
      stu.FirstName = st.FirstName;
      stu.LastName = st.LastName;
      stu.Phone = st.Phone;
      stu.StudentNumber = st.StudentNumber;

      return stu;

    }

    public StudentFull getStudentFull(int? id) {
      var st = dc.Students.FirstOrDefault(n => n.Id == id);

      StudentFull stu = new StudentFull();
      stu.FirstName = st.FirstName;
      stu.LastName = st.LastName;
      stu.Phone = st.Phone;
      stu.StudentNumber = st.StudentNumber;
      stu.Courses = Repo_Courses.getCourseForList(st.Courses);

      return stu;

    }

    //public IEnumerable<StudentPublic> getStudentsPublic()

    public StudentFull createStudent(StudentFull st, string ids) {
      //instantiate new student
      Student stu = new Student(st.FirstName, st.LastName, st.Phone, st.StudentNumber);

      //create a list of ints
      List<Int32> ls = new List<int>();

      //the format of ids is ("n,n,n,...") where n is an numeric character
      //split the string into an array of individual characters
      var nums = ids.Split(',');

      //convert each character to an int32 and store in ls
      foreach (var item in nums) {
        ls.Add(Convert.ToInt32(item));
      }

      //iterate through ls and for each id in the list, add a Course to the student's Courses collection
      foreach (var item in ls) {
        stu.Courses.Add(dc.Courses.FirstOrDefault(n => n.Id == item));
      }
      //add the student to the DataContext
      dc.Students.Add(stu);

      //savechanges is the equivalent to a database commit statement
      dc.SaveChanges();

      //return a copy of the new Student as a StudentFull
      return getStudentFull(stu.Id);
    }

    public StudentFull createStudent(StudentFull st) {
      //instantiate new student
      Student stu = new Student(st.FirstName, st.LastName, st.Phone, st.StudentNumber);

      dc.Students.Add(stu);

      //savechanges is the equivalent to a database commit statement
      dc.SaveChanges();

      //return a copy of the new Student as a StudentFull
      return getStudentFull(stu.Id);
    }
  }
}