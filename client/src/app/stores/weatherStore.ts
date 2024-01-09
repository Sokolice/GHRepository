import { makeAutoObservable } from "mobx";

export default class WeatherStore {

    defLongtitude = 18.262;
    defLatitude = 49.817;

    constructor() {
        makeAutoObservable(this)
    }




}