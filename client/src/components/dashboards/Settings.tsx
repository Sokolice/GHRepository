import { observer } from "mobx-react-lite";
import GoogleMapReact from 'google-map-react';
import { store } from "../../app/stores/store";
import { Container, Grid, GridColumn, Label, Segment } from "semantic-ui-react";

const SettingsComponent = observer(function Settings() {
    const myKey = "AIzaSyB7hNWXlCZqHLOD7_cRvB9SB5kLR-ffsOw";
    const defaultProps = {
        center: {
            lat: 49.83444753300095,
            lng: 18.27903846679619
        },
        zoom: 11
    };

    function handleClick(e: GoogleMapReact.ClickEventValue) {
        store.weatherStore.latitude = e.lat;
        store.weatherStore.longtitude = e.lng;        
    }

    return (
        <Grid>
            <GridColumn style={{ height: '40vh', width: '40%' }}>
            <GoogleMapReact
                bootstrapURLKeys={{ key: myKey }}
                defaultCenter={defaultProps.center}
                defaultZoom={defaultProps.zoom}
                    onClick={(e) => handleClick(e)}
                
            >
                
            </GoogleMapReact>
            </GridColumn>
            <GridColumn>
                <Label> lt: {store.weatherStore.latitude}</Label>
                <Label> lon: {store.weatherStore.longtitude}</Label>
            </GridColumn>
        </Grid>
    )


})
export default SettingsComponent;