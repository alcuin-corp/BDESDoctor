﻿// <copyright file="NationalityTranscoder.cs" company="Alcuin">
// Copyright (c) Alcuin. All rights reserved.
// </copyright>

using Alcuin.BDES.Model;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal class NationalityTranscoder : Transcoder<Nationality>
    {
        public NationalityTranscoder()
        {
            this.Map(
                Nationality.French,
                "Francaise",
                "Français",
                "France",
                "Fr");

            this.Map(Nationality.Other, "autre");
        }
    }
}
