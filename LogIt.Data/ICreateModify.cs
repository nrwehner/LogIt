using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public interface ICreateModify
    {
        string CreatedBy { get;}
        DateTimeOffset CreatedUtc { get;}
        string ModifiedBy { get;}
        DateTimeOffset? ModifiedUtc { get;}
    }
}
