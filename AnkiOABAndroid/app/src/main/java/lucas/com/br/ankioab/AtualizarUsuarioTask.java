package lucas.com.br.ankioab;

import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonEncoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class AtualizarUsuarioTask extends AsyncTask<Usuario, Void, Void> {
    @Override
    protected Void doInBackground(Usuario... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            UsuarioRequest request = Feign.builder().
                    encoder(new GsonEncoder()).
                    target(UsuarioRequest.class, "https do visual studio");

            // 2. Fazendo a chamada e enviando o objeto convertido em JSON
            request.updateUsuario(params[0].getCodUsuario(), params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar atualizar Usuario!");
            e.printStackTrace();
            return null;
        }
    }

}
