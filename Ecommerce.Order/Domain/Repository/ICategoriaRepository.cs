﻿using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICategoriaRepository : ICommonRepository<Categoria>
    {

        void Incluir(Categoria categoria);
        Task<bool> SaveAllAsync();
        void Alterar(Categoria categoria);
        void Excluir(Categoria categoria);
        Task<Categoria> SelecionarByPK(int id);
        Task<IEnumerable<Categoria>> SelecionarTodos();

        Task<CategoriaDTO> GetById(int id);

    }
}
