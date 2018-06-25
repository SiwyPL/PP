package com.example.user.pizzaap;


import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Checkable;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;


/**
 * A simple {@link Fragment} subclass.
 */
public class BlankFragment extends Fragment {


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_blank, container, false);
    // 表
        //    示データ
        List<String> dataList = new ArrayList<String>();
dataList.add("Portakl");
dataList.add(("smieci"));
        // 初期選択位置
        int initSelectedPosition = 3;

        TestAdapter adapter = new TestAdapter(getActivity(), dataList);
        ListView listView = (ListView) view.findViewById(R.id.list);
        listView.setAdapter(adapter);
        listView.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        listView.setItemChecked(initSelectedPosition, true);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                // 選択状態を要素(checkable)へ反映
                Checkable child = (Checkable) parent.getChildAt(position);
                child.toggle();
            }
        });
        return view;
    }

    private static class TestAdapter extends ArrayAdapter<String> {

        private LayoutInflater inflater;

        public TestAdapter(Context context, List<String> dataList) {
            super(context, 0, dataList);
            inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            final ViewHolder holder;
            if (convertView == null) {
                convertView = inflater.inflate(R.layout.inflaterlistcolumn, null);
                holder = new ViewHolder();
                holder.text = (TextView) convertView.findViewById(R.id.text);
                convertView.setTag(holder);
            } else {
                holder = (ViewHolder) convertView.getTag();
            }

            // bindData
            holder.text.setText(getItem(position));
            return convertView;
        }
    }

    private static class ViewHolder {
        TextView text;
    }
}