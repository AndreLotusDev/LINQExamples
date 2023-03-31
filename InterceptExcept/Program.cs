class Employee
{
    public string Name { get; set; }
    public string Id { get; set; }
}

static class EmployeeTraining
{
    public static IEnumerable<Employee> GetProjectManagementTraining()
    {
        // Assume this method returns a list of employees who have completed a training course on project management
        return new List<Employee>();
    }

    public static IEnumerable<Employee> GetLeadershipTraining()
    {
        // Assume this method returns a list of employees who have completed a training course on leadership
        return new List<Employee>();
    }

    public static IEnumerable<Employee> GetEmployeesWithBothTrainings()
    {
        var projectManagementEmployees = GetProjectManagementTraining();
        var leadershipEmployees = GetLeadershipTraining();

        var employeesWithBothTrainings = projectManagementEmployees.Intersect(leadershipEmployees);

        return employeesWithBothTrainings;
    }
}