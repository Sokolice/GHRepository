/* eslint-disable @typescript-eslint/ban-types */
import axios, { AxiosResponse } from 'axios';
import { PlantDTO } from '../models/PlantDTO';
import { MonthSewedRelation } from '../models/MonthSewedRelation';
import { PlantRecordDTO } from '../models/PlantRecordDTO';
import { MonthWeekRelation } from '../models/MonthWeekRelation';

const sleep = (delay: number) => {
    return new Promise((resolve) =>
        setTimeout(resolve, delay))
}

axios.defaults.baseURL = 'http://localhost:5180/api/';


axios.interceptors.response.use(async response => {
    try {
        await sleep(1000)
        return response;
    }
    catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    /*put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),*/
}

const Plants = {
    getPlants: () => requests.get<PlantDTO[]>('/Plants'),
    /*details: (id: string) => requests.get<MonthWeekRelation>(`/activities/${id}`),
    create: (monthweek: MonthWeekRelation) => axios.post('/activities', monthweek),
    update: (monthweek: MonthWeekRelation) => axios.put(`/activities/${monthweek.id}`, monthweek),
    delete: (id: string) => axios.delete(`/activities/${id}`)*/
}

const MonthWeeks = {
    sewingGroupByMonth: () => requests.get<MonthSewedRelation[]>('/MonthWeeks/GetMonthWeeksGrouped'),
    monthWeeksRelations: () => requests.get<MonthWeekRelation[]>('/MonthWeeks/GetMonthWeeksRelation'),
    /*details: (id: string) => requests.get<MonthWeekRelation>(`/activities/${id}`),
    create: (monthweek: MonthWeekRelation) => axios.post('/activities', monthweek),
    update: (monthweek: MonthWeekRelation) => axios.put(`/activities/${monthweek.id}`, monthweek),
    delete: (id: string) => axios.delete(`/activities/${id}`)*/
}

const PlantRecords = {
    getPlantRecords: () => requests.get<PlantRecordDTO[]>('/PlantRecords/GetPlantRecords'),
    create: (plantRecord: PlantRecordDTO) => axios.post('/PlantRecords', plantRecord),

}

const agent = {
    Plants,
    MonthWeeks,
    PlantRecords

}

export default agent;