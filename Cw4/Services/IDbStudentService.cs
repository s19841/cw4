using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw4.Models;
using Cw4.Services;

namespace Cw4.Services { 

    public interface IDbStudentService : IDbService<Student, string>
    {
        public Enrolled GetEnrolled(string indexNumber);
    }
}