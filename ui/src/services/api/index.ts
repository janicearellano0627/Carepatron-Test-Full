import apiClient from "./apiClient";

export const getClients = (): Promise<IClient[]> => {
  return apiClient.get<IClient[]>("api/client/getall");
};

export const getClientFilter = (searchQuery: string): Promise<IClient[]> => {
  return apiClient.get<IClient[]>("api/client/getall?SearchQuery=" + searchQuery.trim());
};

export const createClient = (client: ICreateClient): Promise<string> => {
  return apiClient.post<string>("api/client/create", client);
};

export const updateClient = (client: IClient): Promise<string> => {
  return apiClient.put<string>("api/client/update", client);
};
