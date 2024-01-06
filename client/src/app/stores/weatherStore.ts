import { makeAutoObservable } from "mobx";

export default class WeatherStore {

    longtitude = 0;
    latitude = 0;

    constructor() {
        makeAutoObservable(this)
    }




}