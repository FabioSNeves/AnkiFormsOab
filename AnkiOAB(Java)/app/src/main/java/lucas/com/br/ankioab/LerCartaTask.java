package lucas.com.br.ankioab;

import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class LerCartaTask extends AsyncTask<Integer, Void, Carta> {
    @Override
    protected Carta doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            CartaRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(CartaRequest.class, "https://jsonplaceholder.typicode.com");

            // 2. Fazendo a chamada e recuperando o objeto convertido
            Carta carta = request.getCarta(params[0]);
            return carta;


        } catch (Exception e) {
            System.err.println("Erro na chamada à API "+e.getMessage());
            e.printStackTrace();
            return null;
        }

    }
}
