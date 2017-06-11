package lucas.com.br.ankioab;

import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class LerUsuarioTask extends AsyncTask<String, Void, Usuario> {

    @Override
    protected Usuario doInBackground(String... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            UsuarioRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(UsuarioRequest.class, "http://localhost:58406/api");

            // 2. Fazendo a chamada e recuperando o objeto convertido
            Usuario usuario = request.getUsuario(params[0]);
            return usuario;


        } catch (Exception e) {
            System.err.println("Erro na chamada à API "+e.getMessage());
            e.printStackTrace();
            return null;
        }

    }
}
