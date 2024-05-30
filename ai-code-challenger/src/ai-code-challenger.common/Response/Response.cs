using System.Text.Json.Serialization;

namespace ai_code_challenger.common.Response;

public class Response<TData>
{
    private int _code = Configuration.DefaultStatusCode;

//EM ALGUNS CASOS É NECESSÁRIO ENVIAR UM CONSTRUTOR VAZIO ANTES DE INSTANCIAR UM CONSTRUTOR COMPLETO
    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaultStatusCode;
    public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        //obriga a ter que informar esses dados sempre que eu instanciar a response
        Data = data;
        _code = code;
        Message = message;
    }
    public TData? Data { get; set; }

    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;//sucesso se estiverr entre esses códigos
}
