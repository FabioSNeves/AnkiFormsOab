package lucas.com.br.ankioab;

import feign.Param;
import feign.RequestLine;

/**
 * Created by aluno on 07/06/2017.
 */

public interface UsuarioRequest {

    @RequestLine("GET /Person?id={email}")
    Usuario getUsuario(@Param ("email") String email);

    @RequestLine("DELETE /posts/{id}/")
    void deleteUsuario(@Param("id") Integer id);

    @RequestLine("POST /posts")
    void createUsuario(Usuario usuario);

    @RequestLine("PUT /posts/{id}")
    void updateUsuario(@Param("id") Integer id, Usuario usuario);

}
