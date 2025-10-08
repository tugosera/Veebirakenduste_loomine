using Microsoft.AspNetCore.Mvc;
using Veebirakenduste_loomine.Models;

namespace veebirakendus.Controllers;

[ApiController]
[Route("[controller]")]
public class TootedController
{
    private static List<Toode> _tooted = new List<Toode>{
        new Toode(1,"Koola", 1.5, true),
        new Toode(2,"Fanta", 1.0, false),
        new Toode(3,"Sprite", 1.7, true),
        new Toode(4,"Vichy", 2.0, true),
        new Toode(5,"Vitamin well", 2.5, true)
        };


    // https://localhost:7052/tooted
    [HttpGet]
    public List<Toode> Get()
    {
        return _tooted;
    }

    [HttpGet("kustuta/{index}")]
    public List<Toode> Delete(int index)
    {
        _tooted.RemoveAt(index);
        return _tooted;
    }

    [HttpGet("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
    public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
    {
        Toode toode = new Toode(id, nimi, hind, aktiivne);
        _tooted.Add(toode);
        return _tooted;
    }

    [HttpGet("hind-dollaritesse/{kurss}")] // GET /tooted/hind-dollaritesse/1.5
    public List<Toode> Dollaritesse(double kurss)
    {
        for (int i = 0; i < _tooted.Count; i++)
        {
            _tooted[i].Price = _tooted[i].Price * kurss;
        }
        return _tooted;
    }



    [HttpGet("muuda-aktiivsust/{id}")]
    public List<Toode> MuudaAktiivsust(int id)
    {
        var toode = _tooted.FirstOrDefault(t => t.Id == id);
        if (toode != null)
        {
            toode.IsActive = !toode.IsActive; 
        }
        return _tooted;
    }

    [HttpGet("muuda-nimi/{id}/{uusNimi}")] 
    public List<Toode> MuudaNimi(int id, string uusNimi)
    {
        var toode = _tooted.FirstOrDefault(t => t.Id == id);
        if (toode != null)
        {
            toode.Name = uusNimi;         }
        return _tooted;
    }

    [HttpGet("muuda-hind/{id}/{korrutis}")] 
    public List<Toode> MuudaHind(int id, double korrutis)
    {
        var toode = _tooted.FirstOrDefault(t => t.Id == id);
        if (toode != null)
        {
            toode.Price = toode.Price * korrutis; 
        }
        return _tooted;
    }




    [HttpDelete("kustuta-koik")]
    public string KustutaKoik()
    {
        _tooted.Clear();
        return "Kõik tooted on kustutatud.";
    }

    [HttpPut("muuda-aktiivsust-vale")]
    public List<Toode> MuudaKoikideAktiivsustValele()
    {
        foreach (var toode in _tooted)
        {
            toode.IsActive = false;
        }
        return _tooted;
    }

    [HttpGet("toode/{index}")]
    public Toode GetToodeByIndex(int index)
    {
        if (index < 0 || index >= _tooted.Count)
        {
            return null;
        }
        return _tooted[index];
    }

    [HttpGet("kalleim")]
    public Toode GetKalleimToode()
    {
        if (_tooted.Count == 0)
        {
            return null;
        }
        return _tooted.OrderByDescending(t => t.Price).First();
    }
}