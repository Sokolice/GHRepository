import { makeAutoObservable } from "mobx";
import { WeatherObj } from "../../models/WeatherObj";

export default class WeatherStore {

    defLongtitude = 18.262;
    defLatitude = 49.817;

    currentForecast: WeatherObj | undefined = undefined;
    warning: string = "";

    constructor() {
        makeAutoObservable(this)
    }




}