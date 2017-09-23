package lucas.com.br.ankioab;

import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class ExcluirCartaTask extends AsyncTask<Integer, Void, Void> {

    @Override
    protected Void doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            CartaRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(CartaRequest.class, "https://jsonplaceholder.typicode.com");


            request.deleteCarta(params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar excluir Carta!");
            e.printStackTrace();
            return null;
        }
    }


}
