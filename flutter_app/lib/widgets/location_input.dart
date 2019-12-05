import 'package:flutter/material.dart';
import 'package:flutter_app/models/location.dart';
import 'package:flutter_app/screens/map_screen.dart';
import 'package:location/location.dart';

class LocationInput extends StatefulWidget {
  List<LocationModel> locations;
  LocationInput(this.locations);
  @override
  _LocationInputState createState() => _LocationInputState();
}

class _LocationInputState extends State<LocationInput> {
  Future<void> _selectOnMap() async {
    if (widget.locations != null) {
      final location = await Location().getLocation();
      widget.locations.add(new LocationModel(
          name: "ME", lat: location.latitude, lon: location.longitude));
      await Navigator.of(context).push(
          MaterialPageRoute(builder: (ctx) => MapScreen(widget.locations)));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            FlatButton.icon(
              icon: Icon(Icons.map),
              label: Text('Select on map'),
              textColor: Theme.of(context).primaryColor,
              onPressed: _selectOnMap,
            ),
          ],
        )
      ],
    );
  }
}
