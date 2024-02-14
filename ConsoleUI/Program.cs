using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        Category category = new Category()
        {
            Name = "Yazılım"
        };
        Instructor instructor1 = new Instructor()
        {
            FirstName = "Kazım",
            LastName = "Başar",

        };
        Instructor instructor2 = new Instructor()
        {
            FirstName = "Ahmet",
            LastName = "Mutaf"
        };
        Course course1 = new Course()
        {
            Name = "Python Programlama giriş seviye",
            Description = "Bu python programlama kursu size temel python metotlarını öğretecek ve başlangıç için güzel bir yyol gösterici olacaktır.",
            InstructorId = 1,
            CategoryId = 1,
        };
        Course course2 = new Course()
        {
            Name = "İleri Seviye Java Programala",
            Description = "Java ile ileri seviye teknikleri beraber öğerenelim ve gerçek hayat projelerinde uygulayalım",
            InstructorId = 2,
            CategoryId = 1,
        };
        instructor1.Courses.Add(course1);
        instructor2.Courses.Add(course2);

        category.Courses.Add(course1);
        category.Courses.Add(course2);

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        categoryManager.Add(category);

        InstructorManager instructorManager = new InstructorManager(new EfInstructorDal());
        instructorManager.Add(instructor1);
        instructorManager.Add(instructor2);

        CourseManager courseManager = new CourseManager(new EfCourseDal());
        courseManager.Add(course1);
        courseManager.Add(course2);


    }
}