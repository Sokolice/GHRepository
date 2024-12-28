/* eslint-disable no-useless-catch */
import { makeAutoObservable, runInAction } from "mobx";
import { User, UserFormValues } from "../../models/user";
import agent from "../../api/agent";
import { store } from "./store";
import { router } from "../../router/router";
import { BedRelation } from "../../models/BedRelation";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { PlantDTO } from "../../models/PlantDTO";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import { MonthTaskRelation } from "../../models/MonthTaskRelation";

export default class UserStore {
  user: User | null = null;

  constructor() {
    makeAutoObservable(this);
  }

  get isLoggedIn() {
    return !!this.user;
  }

  login = async (creds: UserFormValues) => {
    try {
      const user = await agent.Account.login(creds);
      store.globalStore.setToken(user.token);
      runInAction(() => {
        this.user = user;
      });
      store.modalStore.closeModal();
    } catch (error) {
      throw error;
    }
  };

  logout = () => {
    store.globalStore.setToken("");
    this.user = null;
    this.invalidateCache();
    router.navigate("/");
  };

  getUser = async () => {
    try {
      const user = await agent.Account.currentUser();
      runInAction(() => {
        this.user = user;
      });
    } catch (error) {
      console.log(error);
    }
  };

  register = async (creds: UserFormValues) => {
    try {
      const user = await agent.Account.register(creds);
      store.globalStore.setToken(user.token);
      runInAction(() => {
        this.user = user;
      });
      store.modalStore.closeModal();
    } catch (error) {
      throw error;
    }
  };

  invalidateCache = () => {
    store.plantRecordStore.plantRecordMap = new Map<string, PlantRecordDTO>();
    store.bedsStore.bedList = new Map<string, BedRelation>();
    store.globalStore.stats = undefined;
    store.plantStore.plantDTOList = new Map<string, PlantDTO>();
    store.monthWeekStore.currentMonthRelationList =
      new Array<MonthSewedRelation>();
    store.monthWeekStore.monthTaskRelations = new Array<MonthTaskRelation>();
  };
}
