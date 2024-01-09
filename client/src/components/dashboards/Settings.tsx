import { observer } from "mobx-react-lite";

import { APIProvider, Map, Marker, useMapsLibrary } from '@vis.gl/react-google-maps';
import { store } from "../../app/stores/store";
import { Grid, GridColumn, GridRow, Header, Icon, Label } from "semantic-ui-react";
import { runInAction } from "mobx";
import { useState } from "react";
import axios from "axios";
import { WeatherObj } from "../../models/WeatherObj";
import Variables from "../../app/variables";

const SettingsComponent = observer(function Settings() {
    const defaultPosition = { lat: 49.8344, lng: 18.2790 };
    const [weatherData, setWeatherData] = useState<WeatherObj>();

    const [warning, setWarning] = useState("");

    const fetchData = async () => {
        try {
            const response = await axios.get(
                `https://api.openweathermap.org/data/2.5/forecast?lat=${store.weatherStore.defLatitude}&lon=${store.weatherStore.defLongtitude}&appid=${Variables.OPEN_WEATHER_API}&lang=cz&units=metric`
            );
            setWeatherData(response.data);
            console.log(response.data); //You can see all the weather data in console log
        } catch (error) {
            console.error(error);
        }
    };
    //const markers = useState
    

    fetchData().then(() => {

        const belowZero = weatherData?.list.find(a => a.main.temp < 0);
        const highTemp = weatherData?.list.find(a => a.main.temp > 28);

        if (belowZero)
            setWarning("Riziko mrazu, chrante rostliny");
        if (highTemp)
            setWarning("Vysoke teploty, uzposobte zalivku");
        
    }
    );


    return (
        <Grid columns={3}>
            <GridColumn style={{ height: '40vh', width: '40%' }}>
                <APIProvider apiKey={Variables.GOOGLE_API_KEY}>
                    <Map center={defaultPosition} zoom={10}>
                        
                    </Map>
            </APIProvider>
            </GridColumn>
            <GridColumn>
                
                {weatherData ? (
                    <>
                        <GridRow><Header>{weatherData.city.name}</Header></GridRow>
                        <GridRow><Header> souradnice: {store.weatherStore.defLatitude} {store.weatherStore.defLongtitude}</Header> </GridRow>
                        <GridRow><Icon name='warning sign'></Icon>{warning}</GridRow>
                
                    </>
                ) : (
                    <p>Loading weather data...</p>
                )}
            </GridColumn>
        </Grid>
    )


})
export default SettingsComponent;