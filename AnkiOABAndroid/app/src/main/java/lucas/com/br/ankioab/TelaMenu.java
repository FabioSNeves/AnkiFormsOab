package lucas.com.br.ankioab;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;

public class TelaMenu extends AppCompatActivity {

    LerBaralhoTask lerBaralhoTask;
    Button addCarta, addBaralho;
    ListView listViewBaralho;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_menu);

        addCarta = (Button) findViewById(R.id.botaoAddCard);
        addBaralho = (Button) findViewById(R.id.botaoAddDeck);
        listViewBaralho = (ListView) findViewById(R.id.listViewBaralho);


    }

    public void adicionarCarta(View v)
    {
        Intent addCarta = new Intent(this, AdicionarCarta.class);
        startActivity(addCarta);
    }
    public void adicionarBaralho(View v)
    {
        Intent addBaralho = new Intent(this, AdicionarBaralho.class);
        startActivity(addBaralho);
    }

    public void game (View v)
    {
        Intent game = new Intent(this, Game.class);
        startActivity(game);
    }


}
