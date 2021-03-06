﻿using System.Collections.Generic;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public interface IMaquinaRepositorio : IRepositorio<Maquina>
    {
        Maquina BuscarPorIdModelo(int id);
        ModeloMaquina RetornaNomeMaquina(Maquina maquina);
    }
}
