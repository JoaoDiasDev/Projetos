using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public static string NomeMunicipio { get; set; }
        public static int CodigoIBGEMunicipio { get; set; }
        public static string NomeMunicipioAlterado { get; set; }
        public static int CodigoIBGEMunicipioAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdUf { get; set; }

        public List<MunicipioDto> listaDto = new List<MunicipioDto>();
        public MunicipioDto municipioDto;
        public MunicipioDtoCompleto municipioDtoCompleto;
        public MunicipioDtoCreate municipioDtoCreate;
        public MunicipioDtoCreateResult municipioDtoCreateResult;
        public MunicipioDtoUpdate municipioDtoUpdate;
        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTestes()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.StreetAddress();
            CodigoIBGEMunicipio = Faker.RandomNumber.Next(1, 10000);
            NomeMunicipioAlterado = Faker.Address.StreetAddress();
            CodigoIBGEMunicipioAlterado = Faker.RandomNumber.Next(1, 10000);
            IdUf = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                };
                listaDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                UfId = IdUf,
                CodIBGE = CodigoIBGEMunicipio
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                }
            };

            municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = NomeMunicipio,
                UfId = IdUf,
                CodIBGE = CodigoIBGEMunicipio
            };

            municipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                Id = IdMunicipio,
                UfId = IdUf,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                CreateAt = DateTime.UtcNow
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = IdMunicipio,
                UfId = IdUf,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEMunicipioAlterado
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                CodIBGE = CodigoIBGEMunicipioAlterado,
                Nome = NomeMunicipioAlterado,
                Id = IdMunicipio,
                UfId = IdUf,
                UpdateAt = DateTime.UtcNow
            };
        }

    }
}
