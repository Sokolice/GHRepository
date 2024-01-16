import { observer } from "mobx-react-lite";

import { APIProvider, Map,} from '@vis.gl/react-google-maps';
import { store } from "../../app/stores/store";
import { Grid, GridColumn, GridRow, Header, Icon } from "semantic-ui-react";
import axios from "axios";
import Variables from "../../app/variables";
import { useEffect } from "react";

const SettingsComponent = observer(function Settings() {
    const defaultPosition = { lat: 49.8344, lng: 18.2790 };

    useEffect(() => {
        if (store.weatherStore.currentForecast == undefined) {
            fetchData();
        }
    }, [store.weatherStore.currentForecast])

    const fetchData = async () => {
        try {
            const response = await axios.get(
                `https://api.openweathermap.org/data/2.5/forecast?lat=${store.weatherStore.defLatitude}&lon=${store.weatherStore.defLongtitude}&appid=${Variables.OPEN_WEATHER_API}&lang=cz&units=metric`
            );
            store.weatherStore.currentForecast =response.data;

            const belowZero = store.weatherStore.currentForecast?.list.find(a => a.main.temp < 0);
            const highTemp = store.weatherStore.currentForecast?.list.find(a => a.main.temp > 28);

            if (belowZero)
                store.weatherStore.warning = "Riziko mrazu, chrante rostliny";
            if (highTemp)
                store.weatherStore.warning = "Vysoke teploty, uzpusobte zalivku";

        } catch (error) {
            console.error(error);
        }
    };


    return (
        <Grid columns={3}>
            <GridColumn style={{ height: '40vh', width: '40%' }}>
                <APIProvider apiKey={Variables.GOOGLE_API_KEY}>
                    <Map center={defaultPosition} zoom={10}>
                        
                    </Map>
            </APIProvider>
            </GridColumn>
            <GridColumn>

                {store.weatherStore.currentForecast ? (
                    <>
                        <GridRow><Header>{store.weatherStore.currentForecast.city.name}</Header></GridRow>
                        <GridRow><Header> souradnice: {store.weatherStore.defLatitude} {store.weatherStore.defLongtitude}</Header> </GridRow>
                        <GridRow><Icon name='warning sign'></Icon>{store.weatherStore.warning}</GridRow>
                
                    </>
                ) : (
                    <p>Loading weather data...</p>
                )}
            </GridColumn>
        </Grid>
    )


})
export default SettingsComponent;