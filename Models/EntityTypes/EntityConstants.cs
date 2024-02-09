namespace testSibers.Models.EntityTypes;

//Значения для валидации
public static class EntityConstants
{
    public static class Projects
    {
        public static readonly Size Name = new(3, 128);
        public static readonly Size ClientCompany = new(1, 300);
        public static readonly Size ContractorCompany = new(1, 300);
        public static readonly DateTime StartDateMin = new(2020, 1, 1);
        public static readonly DateTime EndDateMin = new(2020, 1, 1);
        public static readonly Size PriorityValues = new(1, 10);

    }
    
    public static class User
    {
        public static readonly Size FirstName = new(1, 128);
        public static readonly Size LastName = new(1, 128);
        public static readonly Size MiddleName = new(1, 128);
        public static readonly Size Email = new(3, 128);
        public static readonly Size Password = new(1, 30);
    }
    
    public static class Task
    {
        public static readonly Size Name = new(1, 128);
        public static readonly Size Comment = new(1, 1024);
        public static readonly Size PriorityValues = new(1, 10);
    }

    public record Size(int Min, int Max)
    {
        public Size(int exact) : this(exact, exact) {}
    }
}