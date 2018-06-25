package com.example.user.pizzaap;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.JsonReader;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SearchView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;


public class MainActivity extends AppCompatActivity {
    private class StableArrayAdapter extends ArrayAdapter<String> {

        HashMap<String, Integer> mIdMap = new HashMap<String, Integer>();

        public StableArrayAdapter(Context context, int textViewResourceId,
                                  List<String> objects) {
            super(context, textViewResourceId, objects);
            for (int i = 0; i < objects.size(); ++i) {
                mIdMap.put(objects.get(i), i);
            }
        }
    }

    private ProgressDialog pDialog;
    private ListView lv;
    private String TAG = MainActivity.class.getSimpleName();
    private  String response = "/";
    CharSequence query;
    ArrayList<HashMap<String, String>> contactList = new ArrayList<HashMap<String, String>>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Button SearchButton = (Button) findViewById(R.id.SearchRestaurantButton);
        final SearchView Search = (SearchView) findViewById(R.id.SearchRestaurant);
        lv = (ListView) findViewById(R.id.ListOfRestaurants);

        SearchButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                 query = Search.getQuery();
                new GetContacts().execute();
            }
        });
      lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
          @Override
          public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

              try {
                  String selectedFromList = (lv.getItemAtPosition(position).toString());
                  String[] sl = selectedFromList.split(",");
                  String[] Pl = sl[sl.length - 1].split("=");
                  String Pk = Pl[Pl.length - 1].replace("}", "");
                  OpenRestaurantActivity(Integer.parseInt(Pk));
              }
              catch (Exception p)
              {
                Log.e("tag",p.toString());
              }
          }
      });

       //

    }
    public void OpenRestaurantActivity(int i)
    {
        Intent intent = new Intent(this,Restaurant.class);
        intent.putExtra("RestaurantID",i);
        startActivity(intent);

    }

    private class GetContacts extends AsyncTask<Void, Void, Void> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            // Showing progress dialog


        }

        @Override
        protected Void doInBackground(Void... arg0) {
            HttpHandler sh = new HttpHandler();

            // Making a request to url and getting response
            String jsonStr = sh.makeServiceCall(ApiStrings.NearestRestaurantsURL+query);

            Log.e(TAG, "Response from url: " + jsonStr);

            if (jsonStr != null) {
                try {
                    JSONObject jsonObj = new JSONObject(jsonStr);
                    JSONArray Restaurants = jsonObj.getJSONArray("list");

                    // Getting JSON Array node
                    //JSONArray Restaurants = new JSONArray(jsonStr);

                    // looping through All Contacts
                    for (int i = 0; i < Restaurants.length(); i++) {
                        JSONObject d = Restaurants.getJSONObject(i);
                        JSONObject c = d.getJSONObject("restaurant");

                        String id = c.getString("id");
                        String name = c.getString("name");
                     //   JSONArray distan = jsonObj.getJSONArray("distance");
                      //  String distance = distan.getString("distance");
                        HashMap<String, String> contact = new HashMap<>();
                        String distance = d.getString("distance");

                        // adding each child node to HashMap key => value
                        contact.put("id", id);
                        contact.put("name", name);
                       contact.put("distance",distance);


                        // adding contact to contact list
                        contactList.add(contact);
                    }
                }catch (final Exception e )
                {
                    Log.e(TAG, "Json parsing error: " + e.getMessage());
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(getApplicationContext(),
                                    "Json parsing error: " + e.getMessage(),
                                    Toast.LENGTH_LONG)
                                    .show();
                        }
                    });

                }


            } else {
                Log.e(TAG, "Couldn't get json from server.");
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(getApplicationContext(),
                                "Couldn't get json from server. Check LogCat for possible errors!",
                                Toast.LENGTH_LONG)
                                .show();
                    }
                });

            }

            return null;
        }


    @Override
    protected void onPostExecute(Void result) {
        super.onPostExecute(result);
        // Dismiss the progress dialog

        /**
         * Updating parsed JSON data into ListView
         * */
        ListAdapter adapter = new SimpleAdapter(
               MainActivity.this, contactList,
                R.layout.listitem, new String[]{"name","id","distance"
               }, new int[]{R.id.name,R.id.id,R.id.distance});

       lv.setAdapter(adapter);
    }
}


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
