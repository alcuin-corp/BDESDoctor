using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class RecognitionTypeTranscoder : Transcoder<RecognitionType>
    {
        public RecognitionTypeTranscoder()
        {
            this.Map(
                RecognitionType.RQTH,
                "RQTH",
                "Travailleur handicape",
                "Travailleur handicapé");
        }
    }
}