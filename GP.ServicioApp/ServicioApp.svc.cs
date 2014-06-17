using System;
using System.Collections.Generic;
using System.Text;
using GP.DTO.DTO;
using GP.Gestores.Gestores;
using GP.Servicio.DataContracts;
using GP.Servicio.Interfaces;
using Log;

namespace GP.ServicioApp
{
    public class ServicioValor : IServicioValor
    {
        private ValorGestor _valorGestor;

        public ServicioValor()
        {
            _valorGestor = new ValorGestor();
        }

        public void Save(ValorDataContract entity)
        {
            try
            {
                var valorDTO = ValorDataContractaDTO(entity);
                _valorGestor.Save(valorDTO);
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
        }

        public void Edit(ValorDataContract entity)
        {
            try
            {
                var valorDTO = ValorDataContractaDTO(entity);
                _valorGestor.Edit(valorDTO);
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
        }

        public void Enable(ValorDataContract entity)
        {
            try
            {
                var valorDTO = ValorDataContractaDTO(entity);
                _valorGestor.Enable(valorDTO);
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
            
        }

        public void Disable(ValorDataContract entity)
        {
            try
            {
                var valorDTO = ValorDataContractaDTO(entity);
                _valorGestor.Disable(valorDTO);
            }
            catch (Exception)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
        }

        public ValorDataContract ObtainId(int id)
        {
            try
            {
                var valorDTO = _valorGestor.ObtainId(id);
                return DTOaValorDataContract(valorDTO);
            }
            catch (Exception)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
        }

        public IList<ValorDataContract> ObtainAll()
        {
            try
            {
                IList<ValorDataContract> valorDataContractLista = new List<ValorDataContract>();
                IList<ValorDTO> valorDtoLista = _valorGestor.ObtainAll();
                foreach (ValorDTO f in valorDtoLista)
                    valorDataContractLista.Add(DTOaValorDataContract(f));
                return valorDataContractLista;
            }
            catch (Exception)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
            }
        }

        private String Validate(ValorDataContract valorDataContract)
        {
            var s = new StringBuilder().Clear();

            if (!((valorDataContract.Influencia) >= 0 && (valorDataContract.Influencia) <= 2))
                s.Append("La Influencia del Valor es Incorrecta.");

            if (String.IsNullOrEmpty(valorDataContract.Nombre))
                s.Append("El Nombre no puede ser vacio.");

            if (!((valorDataContract.Deshabilitado) == 0 || (valorDataContract.Deshabilitado) == 1))
                s.Append("La opcion deshabilitar debe valer 0 (no) o 1 (si)");

            return s.ToString();
        }

        private ValorDataContract DTOaValorDataContract(ValorDTO valorDTO)
        {
            var valorDataContract = new ValorDataContract();

            if (valorDTO.ValorId > 0)
                valorDataContract = ObtainId(valorDTO.ValorId);

            valorDataContract.ValorId = valorDTO.ValorId;
            valorDataContract.Nombre = valorDTO.Nombre;
            valorDataContract.Deshabilitado = valorDTO.Deshabilitado;
            valorDataContract.Influencia = valorDTO.Influencia;

            return valorDataContract;
        }

        private ValorDTO ValorDataContractaDTO(ValorDataContract valorDataContract)
        {
            var valorDTO = new ValorDTO();

            valorDTO.ValorId = valorDataContract.ValorId;
            valorDTO.Nombre = valorDataContract.Nombre;
            valorDTO.Deshabilitado = valorDataContract.Deshabilitado;
            valorDTO.Influencia = valorDataContract.Influencia;

            return valorDTO;
        }
    }
}
