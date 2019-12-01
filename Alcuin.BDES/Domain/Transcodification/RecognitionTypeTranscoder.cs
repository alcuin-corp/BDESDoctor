// <copyright file="RecognitionTypeTranscoder.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

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
