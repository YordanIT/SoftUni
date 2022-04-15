namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProjectExportDto[]), new XmlRootAttribute("Projects"));
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using var sw = new StringWriter(sb);

            var projectsWIthTasks = context.Projects.Where(p => p.Tasks.Any())
                                                    .ToArray()
                                                    .Select(p => new ProjectExportDto
                                                    {
                                                        Name = p.Name,
                                                        HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                                                        TasksCount = p.Tasks.Count(),
                                                        Tasks = p.Tasks.ToArray()
                                                        .Select(t => new TaskExportDto
                                                        {
                                                            Name = t.Name,
                                                            Label = t.LabelType.ToString()
                                                        })
                                                        .OrderBy(t => t.Name)
                                                        .ToArray()
                                                    })
                                                    .OrderByDescending(p => p.TasksCount)
                                                    .ThenBy(p => p.Name)
                                                    .ToArray();

            xmlSerializer.Serialize(sw, projectsWIthTasks, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees.Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                                             .ToArray()
                                             .Select(e => new
                                             {
                                                 e.Username,
                                                 Tasks = e.EmployeesTasks.Where(et => et.Task.OpenDate >= date)
                                                                         .ToArray()
                                                                         .OrderByDescending(et => et.Task.DueDate)
                                                                         .ThenBy(et => et.Task.Name)
                                                                         .Select(t => new
                                                 {
                                                     TaskName = t.Task.Name,
                                                     OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                                     DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                                     LabelType = t.Task.LabelType.ToString(),
                                                     ExecutionType = t.Task.ExecutionType.ToString()
                                                 }).ToArray()
                                             })
                                             .OrderByDescending(e => e.Tasks.Count())
                                             .ThenBy(e => e.Username)
                                             .Take(10)
                                             .ToArray();

            string result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}