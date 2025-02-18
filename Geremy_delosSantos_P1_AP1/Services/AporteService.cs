using Geremy_delosSantos_P1_AP1.Models;
using Geremy_delosSantos_P1_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Geremy_delosSantos_P1_AP1.Services;

public class AporteService(IDbContextFactory<Contexto> Dbfactory)
{
    public async Task<bool> Guardar(Aporte aporte)
    {
        if (await Existe(aporte.AporteId))
            return await Modificar(aporte);
        else
            return await Insertar(aporte);
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        return await contexto.Aporte.AnyAsync(i => i.AporteId == id);
    }

    public async Task<bool> Insertar(Aporte modelo)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        contexto.Aporte.Add(modelo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Aporte modelo)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        contexto.Entry(modelo).State = EntityState.Modified;
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Aporte?> Buscar(int id)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        return await contexto.Aporte.FirstOrDefaultAsync(i => i.AporteId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        return await contexto.Aporte
            .AsNoTracking()
            .Where(i => i.AporteId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Aporte>> Listar(Expression<Func<Aporte, bool>> criterio)
    {
        await using var contexto = await Dbfactory.CreateDbContextAsync();
        return await contexto.Aporte
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
