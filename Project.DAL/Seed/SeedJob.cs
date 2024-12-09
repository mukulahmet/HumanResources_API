using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Seed
{
    public class SeedJob : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(
                new Job { JobID = 1, JobName = "Director" },
                new Job { JobID = 2, JobName = "Developer" },
                new Job { JobID = 3, JobName = "Data Analyst" },
                new Job { JobID = 4, JobName = "Data Scientist" },
                new Job { JobID = 5, JobName = "Database Expert" },
                new Job { JobID = 6, JobName = "AI Expert" },
                new Job { JobID = 7, JobName = "Human Resources" },
                new Job { JobID = 8, JobName = "Technical Support" }
                );

        }
    }
}
