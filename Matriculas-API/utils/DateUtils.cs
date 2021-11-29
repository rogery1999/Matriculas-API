namespace Matriculas_API.Utils;

public class DateUtils
{
    public static DateTime FromStringToDatetime(string date)
    {

        var fecha = date.Split('-');

        if (fecha.Length != 3) throw new Exception("El formanto de la fecha es invalido");

        try
        {
            return new DateTime(Int32.Parse(fecha[0]), Int32.Parse(fecha[1]), Int32.Parse(fecha[2]));
        }
        catch (Exception)
        {
            throw new Exception("El formanto de la fecha es invalido");
        }

    }
}