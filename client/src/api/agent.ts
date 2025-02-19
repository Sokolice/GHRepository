/* eslint-disable @typescript-eslint/ban-types */
import axios, { AxiosResponse } from "axios";
import { PlantDTO } from "../models/PlantDTO";
import { MonthSewedRelation } from "../models/MonthSewedRelation";
import { PlantRecordDTO } from "../models/PlantRecordDTO";
import { MonthWeekRelation } from "../models/MonthWeekRelation";
import { BedRelation } from "../models/BedRelation";
import { PestRelation } from "../models/PestRelation";
import {
  MonthTaskRelation,
  WeekTaskRelation,
} from "../models/MonthTaskRelation";
import { PlantPlantsRelation } from "../models/PlantPlantsRelation";
import { GardeningTaskDTO } from "../models/GardeningTaskDTO";
import { HarvestDTO } from "../models/HarvestDTO";
import { User, UserFormValues } from "../models/user";
import { store } from "../app/stores/store";
import { PlantTypePlantsRelation } from "../models/PlantTypePlantsRelation";
import { PlantTypeDTO } from "../models/PlantTypeDTO";
import { Statistics } from "../models/Stats";

const sleep = (delay: number) => {
  return new Promise((resolve) => setTimeout(resolve, delay));
};

axios.defaults.baseURL = import.meta.env.VITE_API_URL;

axios.interceptors.request.use((config) => {
  const token = store.globalStore.token;
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

axios.interceptors.response.use(async (response) => {
  try {
    await sleep(1000);
    return response;
  } catch (error) {
    console.log(error);
    return await Promise.reject(error);
  }
});

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  /*del: <T>(url: string) => axios.delete<T>(url).then(responseBody),*/
};

const Plants = {
  getPlants: () => requests.get<PlantDTO[]>("/Plants"),
  details: (id: string) => requests.get<PlantDTO>(`/Plants/${id}`),
  getOtherPlants: (id: string) =>
    requests.get<PlantPlantsRelation>(`/Plants/GetOtherPlants?id=${id}`),
  getAllPlantsRelations: () =>
    requests.get<PlantPlantsRelation[]>("/Plants/GetAllPlantsRelations"),
  harvest: (harvest: HarvestDTO) =>
    requests.post<HarvestDTO>("Harvest", harvest),
  getAllAvailablePlants: () =>
    requests.get<PlantTypePlantsRelation[]>("/Plants/GetAllAvailablePlants"),
  savePlantsForUser: (ids: string[]) =>
    requests.post<string[]>("Plants/SavePlantsForUser", ids),
  getAllPlantTypes: () =>
    requests.get<PlantTypeDTO[]>("/Plants/GetAllPlantTypes"),
  createNewPlant: (plant: PlantDTO) =>
    requests.post<PlantTypeDTO>("/Plants/CreatePlant", plant),
  /*create: (monthweek: MonthWeekRelation) => axios.post('/activities', monthweek),
    getAllPlantTypes: () => requests.get<PlantTypeDTO[]>('/Plants/GetAllPlantTypes'),
    update: (monthweek: MonthWeekRelation) => axios.put(`/activities/${monthweek.id}`, monthweek),
    delete: (id: string) => axios.delete(`/activities/${id}`)*/
};

const MonthWeeks = {
  sewingGroupByMonth: () =>
    requests.get<MonthSewedRelation[]>("/MonthWeeks/GetMonthWeeksGrouped"),
  monthWeeksRelations: () =>
    requests.get<MonthWeekRelation[]>("/MonthWeeks/GetMonthWeeksRelation"),
  /*details: (id: string) => requests.get<MonthWeekRelation>(`/activities/${id}`),
    create: (monthweek: MonthWeekRelation) => axios.post('/activities', monthweek),
    update: (monthweek: MonthWeekRelation) => axios.put(`/activities/${monthweek.id}`, monthweek),
    delete: (id: string) => axios.delete(`/activities/${id}`)*/
};

const PlantRecords = {
  getPlantRecords: () =>
    requests.get<PlantRecordDTO[]>("/PlantRecords/GetPlantRecords"),
  create: (plantRecord: PlantRecordDTO) =>
    axios.post("/PlantRecords", plantRecord),
  delete: (id: string) => axios.delete(`/PlantRecords/${id}`),
  update: (plantRecord: PlantRecordDTO) =>
    axios.put(`/PlantRecords/${plantRecord.id}`, plantRecord),
  details: (id: string) => requests.get<PlantRecordDTO>(`/PlantRecords/${id}`),
};
const Beds = {
  getBeds: () => requests.get<BedRelation[]>("/Beds/GetBeds"),
  create: (bedRelation: BedRelation) =>
    axios.post("/Beds/PostBed", bedRelation),
  delete: (id: string) => axios.delete(`/Beds/${id}`),
  update: (bedRelation: BedRelation) =>
    requests.put<BedRelation>(`/Beds/${bedRelation.bed.id}`, bedRelation),
  details: (id: string) => requests.get<BedRelation>(`/Beds/${id}`),
};

const Cells = {
  deleteCells: (ids: Array<string>) => axios.patch(`/Cells/DeleteCells`, ids),
};

const Pests = {
  getPests: () => requests.get<PestRelation[]>("/Pests"),
};

const Tasks = {
  getTasks: () => requests.get<MonthTaskRelation[]>("/GardeningTasks"),
  setTask: (task: GardeningTaskDTO) =>
    requests.post<GardeningTaskDTO>("/GardeningTasks", task),
  shareTasks: (weekTasks: WeekTaskRelation) =>
    requests.post<WeekTaskRelation>("/GardeningTasks/ShareTasks", weekTasks),
};

const Stats = {
  getStats: () => requests.get<Statistics>("/Stats/GetStats"),
};

const Account = {
  currentUser: () => requests.get<User>("/account"),
  login: (user: UserFormValues) => requests.post<User>("/account/login", user),
  register: (user: UserFormValues) =>
    requests.post<User>("account/register", user),
};

const agent = {
  Plants,
  MonthWeeks,
  PlantRecords,
  Beds,
  Cells,
  Pests,
  Tasks,
  Stats,
  Account,
};

export default agent;
