using System;
using System.Collections.Generic;
using System.Linq;
using GP.DTO.DTO;
using GP.Dominio.Models;
using GP.Repositorio.Repositories;
using Log;

namespace GP.Gestores.Gestores
{
    public class FactorGestor : IGestor<FactorDTO>, IDisposable
    {
        private Factor _factor;

        private readonly FactorRepository _factorRepository;
        private readonly ValorRepository _valorRepository;

        Logger _log;

        public FactorGestor()
        {
            try
            {
                _factorRepository = new FactorRepository();
                _valorRepository = new ValorRepository();
            }
            catch (Exception e)
            {
                _log.WriteLog(e.ToString());
            }
        }

        public void Save(FactorDTO entity)
        {
            try
            {
                _factor = DTOFactorAFactor(entity);

                _factorRepository.Create(_factor);
            }
            catch (Exception e)
            {
                _log.WriteLog(e.ToString());
            }

        }

        public void Edit(FactorDTO entity)
        {
            try
            {
                _factor = DTOFactorAFactor(entity);

                _factorRepository.Update(_factor);
            }
            catch (Exception e)
            {
                _log.WriteLog(e.ToString());
            }
        }

        public void Enable(FactorDTO entity)
        {
            entity.Deshabilitado = 0;
            Edit(entity);
        }

        public void Disable(FactorDTO entity)
        {
            entity.Deshabilitado = 1;
            Edit(entity);
        }

        public FactorDTO ObtainId(int id)
        {
            var f = _factorRepository.GetByID(id);
            return FactorAFactorDTO(f);
        }

        public IList<FactorDTO> ObtainAll()
        {
            Dispose();

            IList<Factor> factorLista = _factorRepository.GetAll();

            return factorLista.Select(FactorAFactorDTO).ToList();
        }

        public string Validate(FactorDTO entidad)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _factorRepository.Dispose();
        }

        private Factor DTOFactorAFactor(FactorDTO factorDto)
        {
            var factor = new Factor();

            if (factorDto.FactorId > 0)
            {
                factor = _factorRepository.GetByID(factorDto.FactorId);
            }

            factor.FactorId = factorDto.FactorId;
            factor.Nombre = factorDto.Nombre;
            factor.Deshabilitado = factorDto.Deshabilitado;

            //var valoresSeleccionados = new List<Valor>();
            factor.ValoresSeleccionados.Clear();

            foreach (var valorDto in factorDto.ValoresSeleccionados)
            {
                if (valorDto.ValorId > 0)
                {
                    var valor = _valorRepository.GetByID(valorDto.ValorId);

                    factor.ValoresSeleccionados.Add(valor);
                }
            }

            //factor.ValoresSeleccionados = valoresSeleccionados;

            return factor;
        }

        private FactorDTO FactorAFactorDTO(Factor factor)
        {
            var factorDto = new FactorDTO
            {
                FactorId = factor.FactorId,
                Nombre = factor.Nombre,
                Deshabilitado = factor.Deshabilitado,
            };

            var valoresSeleccionados = new List<ValorDTO>();

            foreach (var valor in factor.ValoresSeleccionados)
            {
                var valorDto = new ValorDTO();

                valorDto.Influencia = valor.Influencia;
                valorDto.ValorId = valor.ValorId;
                valorDto.Nombre = valor.Nombre;

                valoresSeleccionados.Add(valorDto);
            }

            factorDto.ValoresSeleccionados = valoresSeleccionados;

            return factorDto;
        }
    }
}
