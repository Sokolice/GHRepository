/* eslint-disable no-useless-catch */
import { makeAutoObservable, runInAction } from "mobx";
import { User, UserFormValues } from "../../models/user";
import agent from "../../api/agent";
import { store } from "./store";
import { router } from "../../router/router";

export default class UserStore {
    user: User | null = null;

    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            store.globalStore.setToken(user.token);
            runInAction(() => {
                this.user = user
            })
        }
        catch (error) {
            throw error;
        }

    }

    logout = () => {
        store.globalStore.setToken(null);
        this.user = null;
        router.navigate('/');
    }

    getUser = async () => {
        try {
            const user = await agent.Account.currentUser();
            runInAction(() => {
                this.user = user;
            })
        } catch (error) {
            console.log(error);
        }
    }
}