﻿namespace MojaApp.API.Controllers.Dtos
{
    public record StudentGetByIdResponse(
        int StudentId,
        string Ime,
        string Prezime,
        string SlikaStudenta,
        StudentGetByIdResponseOpstina? Opstina
        );

    public record StudentGetByIdResponseOpstina(
        string Naziv,
        string Ptt
        );
}
