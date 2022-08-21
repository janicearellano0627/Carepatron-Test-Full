interface IClient {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
}

interface IApplicationState {
  clients: IClient[];
}

interface ICreateClient {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
}