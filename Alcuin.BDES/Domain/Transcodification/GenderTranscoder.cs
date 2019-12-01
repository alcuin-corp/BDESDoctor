using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class GenderTranscoder : Transcoder<Gender>
    {
        public GenderTranscoder()
        {
            this.Map(
                Gender.Male,
                "Homme",
                "H",
                "M",
                "Male");

            this.Map(
                Gender.Female,
                "Femme",
                "F",
                "Femelle");
        }
    }
}