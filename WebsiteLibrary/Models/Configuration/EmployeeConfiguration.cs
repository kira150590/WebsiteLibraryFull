using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteLibrary.Models.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        //sử dụng fluent API để cấu hình cho bảnh giữ liệu từ entity class
        //tham khảo link: https://tuhocict.com/fluent-api-trong-code-first

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("e310a6cb-6677-4aa6-93c7-2763956f7a97"),
                    Name = "Vũ Đức Dũng",
                    BirthDay = new DateTime(1990, 05, 15),
                    Position = "Software Developer"
                },
                new Employee
                {
                    Id = new Guid("398d10fe-4b8d-4606-8e9c-bd2c78d4e001"),
                    Name = "Trương Thị Khánh Vân",
                    BirthDay = new DateTime(1992, 07, 18),
                    Position = "Software Developer"
                }
            );
        }
    }
}
