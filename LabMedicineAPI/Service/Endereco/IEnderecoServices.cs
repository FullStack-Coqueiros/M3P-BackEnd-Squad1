using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Endereco
{
    public interface IEnderecoServices
    {
        bool DeleteEndereco(int id);
        EnderecoModel EnderecoCreateDTO(EnderecoCreateDTO enderecoCreateDTO);
        EnderecoModel EnderecoUpdateDTO(int id, EnderecoUpdateDTO updateEnderecoDTO);
        IEnumerable<EnderecoGetDTO> Get();
        EnderecoGetDTO GetById(int id);
    }
}