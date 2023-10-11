import axios, { AxiosResponse } from 'axios';
import { MonthWeekRelation } from '../models/MonthWeekRelation';

const sleep = (delay: number) => {
    return new Promise((resolve) =>
        setTimeout(resolve, delay))
}

axios.defaults.baseURL = 'http://localhost:5180/api';


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
    /*post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),*/
}

const MonthWeeks = {
    list: () => requests.get<MonthWeekRelation[]>('/MonthWeeks'),
    /*details: (id: string) => requests.get<MonthWeekRelation>(`/activities/${id}`),
    create: (monthweek: MonthWeekRelation) => axios.post('/activities', monthweek),
    update: (monthweek: MonthWeekRelation) => axios.put(`/activities/${monthweek.id}`, monthweek),
    delete: (id: string) => axios.delete(`/activities/${id}`)*/
}


const agent = {
    MonthWeeks
}

export default agent;