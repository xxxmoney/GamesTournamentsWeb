import axios from 'axios'

const useApi = () => {
  // TODO: fix baseURL
  const baseURL = process.env.API || 'https://localhost:44373/api'

  const mainStore = useMainStore()

  return axios.create({
    baseURL,
    headers: {
      Authorization: `Bearer ${mainStore.loginResult?.token ?? ''}`
    }
  })
}

export { useApi }
