using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public int Score { get; set; }
        public string Reason { get; set; }
        public string Recommendation { get; set; }

        public int DogWalkId { get; set; }
        public virtual DogWalk DogWalk { get; set; }
    }
}
