using System;

namespace IniciativadFideliza.Helpers
{
    public class FusoHorario
    {
        public static DateTime BrasiliaDF()
        {
            // Mesmo estando o servidor configurado para qualquer fuso horário, o código abaixo obtém o horário de Brasília
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"); // Brasilia/BRA
            DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);

            return dateTimeBrasilia;
        }
    }
}
