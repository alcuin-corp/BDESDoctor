using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class AbsenceKindTranscoder : Transcoder<AbsenceKind>
    {
        public AbsenceKindTranscoder()
        {
            this.Map(AbsenceKind.AbsenceMaternite, "Absence Maternite");
            this.Map(AbsenceKind.AbsencePaternite, "Absence Maternite");
        }
    }
}
