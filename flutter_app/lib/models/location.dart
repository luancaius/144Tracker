import 'package:flutter_app/models/vehicleLocation.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

class LocationModel {
  String name;
  double lat;
  double lon;
  LocationModel({this.name, this.lat, this.lon});

  factory LocationModel.convert(VehicleLocation vehicle) {
    return new LocationModel(
        name: vehicle.id,
        lat: double.parse(vehicle.latitude),
        lon: double.parse(vehicle.longitude));
  }

  static Marker convertToMarker(LocationModel locationModel) {
    if (locationModel.name == "ME") {
      return new Marker(
          markerId: MarkerId(locationModel.name),
          position: LatLng(locationModel.lat, locationModel.lon),
          infoWindow: InfoWindow(title: locationModel.name),
          icon:
              BitmapDescriptor.defaultMarkerWithHue(BitmapDescriptor.hueBlue));
    }
    var marker = new Marker(
      markerId: MarkerId(locationModel.name),
      position: LatLng(locationModel.lat, locationModel.lon),
      infoWindow: InfoWindow(title: locationModel.name),
    );
    return marker;
  }
}
