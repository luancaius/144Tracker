import 'package:flutter/material.dart';
import 'package:flutter_app/models/vehicleLocation.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'models/vehicleLocation.dart';

void main() => runApp(MyApp());

class MyApp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return MyAppState();
  }
}

class MyAppState extends State<MyApp> {
  String _route;
  getVehicles() {
    const agency = 'ttc';
    String route = '100';
    String url =
        'http://webservices.nextbus.com/service/publicJSONFeed?command=vehicleLocations&a=' +
            agency +
            '&r=' +
            route +
            '&t=0';
    print("Fazendo get");
    http.get(url).then((response) {
      var result = json.decode(response.body);
      var arrayVehicles = result['vehicle'] as List<dynamic>;
      var vehicleLocations = arrayVehicles.map((item) {return VehicleLocation.fromJson(item);}).toList();
      vehicleLocations.forEach((item) {
        print(item.id + ' ' + item.route);
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
          appBar: AppBar(
            title: Text("Bus Tracker"),
          ),
          body: Column(
            children: <Widget>[
              TextField(
                decoration: InputDecoration(
                    border: InputBorder.none, hintText: 'Enter the route'),
                onChanged: (value) {
                  setState(() {
                    _route = value;
                  });
                },
              ),
              RaisedButton(
                child: Text('Get them ALL'),
                onPressed: () {
                  getVehicles();
                },
              )
            ],
          )),
    );
  }
}
