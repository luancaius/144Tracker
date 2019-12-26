import 'package:flutter/material.dart';
import 'package:flutter_app/models/location.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class MapScreen extends StatefulWidget {
    List<LocationModel> locations;
  MapScreen(this.locations);
  @override
  _MapScreenState createState() => _MapScreenState();
}

class _MapScreenState extends State<MapScreen> {  
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Bus Map'),
      ),
      body: GoogleMap(
        initialCameraPosition: CameraPosition(
            target: LatLng(widget.locations.last.lat, widget.locations.last.lon), zoom: 14),
            markers: widget.locations.map((item){return LocationModel.convertToMarker(item);}).toSet(),
      ),
    );
  }
}
