// <copyright file="TextTranscoder.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class TextTranscoder : Transcoder<char>
    {
        public TextTranscoder()
        {
            this.Map('a', "à");
            this.Map('e', "é", "è");
            this.Map('c', "ç");
            this.Map('u', "ù");
        }
    }
}
